// C++11

#include <iostream>
#include <mutex>
#include <condition_variable>
#include <deque>
#include <thread>

// message structure that is produced / consumed
struct msg {
    int x, y;
    std::string s;

    msg() : s("test") {
        x = std::rand() % 1000000;
        y = std::rand() % 1000000;
    }

    friend std::ostream& operator<<(std::ostream& os, const struct msg d) {
        os << d.x << ", " << d.y << ", " << d.s << "\n";

        return os;
    }
};


// Queue that holds produced items
template <typename T>
class MessageQueue 
{
public:
    MessageQueue(): m_capacity(1) {}
    MessageQueue(size_t s): m_capacity(s) {}

    // add an item at the front of the queue
    void add(T x) {
        std::unique_lock<std::mutex> locker{m_mtx};
        m_cond.wait(locker, [this](){return m_buffer.size() < m_capacity;});
        
        m_buffer.push_front(std::move(x));
        
        locker.unlock();
        m_cond.notify_one();
    }

    void add_move(T&& x) {
        std::unique_lock<std::mutex> locker{m_mtx};
        m_cond.wait(locker, [this](){return m_buffer.size() < m_capacity;});
        
        m_buffer.push_front(std::move(x));
        
        locker.unlock();
        m_cond.notify_one();
    }

    // remove an item from the end of the queue 
    T remove() {
        std::unique_lock<std::mutex> locker(m_mtx);
        m_cond.wait(locker, [this](){return m_buffer.size() > 0;});

        T x = m_buffer.back();
        m_buffer.pop_back();

        locker.unlock();
        m_cond.notify_one();

        return x;
    }

private:
    std::mutex m_mtx;
    std::condition_variable m_cond;

    std::deque<T> m_buffer;
    size_t m_capacity;
};


// concrete message producer
class MessageProducer
{
public:
    MessageProducer(std::string&& id, MessageQueue<struct msg> &buf) 
    : m_id(std::move(id)), m_buf(buf) {}

    void produce() {
        while (true) {
            struct msg x{};
            
            m_buf.add(x);
            std::printf("+ %d\n", x.x);

            int sleep = std::rand() % 1000 + 10;
            std::this_thread::sleep_for(std::chrono::milliseconds(sleep));
        }
    }

private:
    std::string m_id;
    MessageQueue<struct msg> &m_buf;
};



class MessageConsumer
{
public:
    MessageConsumer(std::string&& id, MessageQueue<struct msg> &buf) 
    : m_id(std::move(id)), m_buf(buf) {}

    void consume() {
        while(true) {
            struct msg x = m_buf.remove();
            std::printf("- %d\n", x.x);

            int sleep = std::rand() % 1000 + 10;
            std::this_thread::sleep_for(std::chrono::milliseconds(sleep));
        }
    }

private:
    std::string m_id;
    MessageQueue<struct msg> &m_buf;
};

int main(int argc, char const *argv[])
{
    std::srand(std::time(nullptr));

    if (argc != 2) {
        std::cerr << "Usage: " << argv[0] << " <queue_capacity>\n";
        return -1;
    }

    size_t queue_capacity = std::stoul(argv[1]);

    MessageQueue<struct msg> buffer{queue_capacity};
    MessageProducer prod{"producer1", buffer};
    MessageConsumer cons{"consumer1", buffer};

    std::thread pt{&MessageProducer::produce, prod};
    std::thread ct{&MessageConsumer::consume, cons};

    pt.join();
    ct.join();

    return 0;
}
