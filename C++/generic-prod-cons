// C++11

#include <iostream>
#include <mutex>
#include <condition_variable>
#include <deque>
#include <thread>

struct data {
    int x, y;
    std::string s;

    data() : s("test") {
        x = std::rand() % 1000000;
        y = std::rand() % 1000000;
    }

    friend std::ostream& operator<<(std::ostream& os, const struct data d) {
        os << d.x << ", " << d.y << ", " << d.s << "\n";
    }
};


typedef struct data elem_t;

template <typename T>
class Buffer 
{
public:
    Buffer(): m_size(1) {}
    Buffer(int s): m_size(s) {}

    void add(T x) {
        while (true) {
            std::unique_lock<std::mutex> locker(m_mtx);
            m_cond.wait(locker, [this](){return m_buffer.size() < m_size;});
           
            m_buffer.push_back(x);
            
            locker.unlock();
            m_cond.notify_all();

            return;
        }
    }

    T remove() {
        while (true) {
            std::unique_lock<std::mutex> locker(m_mtx);
            m_cond.wait(locker, [this](){return m_buffer.size() > 0;});

            T x = m_buffer.back();
            m_buffer.pop_back();

            locker.unlock();
            m_cond.notify_all();

            return x;
        }
    }

private:
    std::mutex m_mtx;
    std::condition_variable m_cond;

    std::deque<T> m_buffer;
    unsigned int m_size;
};



template <typename T>
class Producer
{
public:
    Producer() : m_buf(nullptr) {}
    Producer(std::string&& id, Buffer<T> *buf) : m_id(id), m_buf(buf) {}

    void produce() {
        while (true) {
            T x = T();
            
            m_buf->add(x);
            std::cout << x;

            int sleep = std::rand() % 1000 + 10;
            std::this_thread::sleep_for(std::chrono::milliseconds(sleep));
        }
    }

private:
    Buffer<T> *m_buf;
    std::string m_id;
};



template <typename T = int>
class Consumer
{
public:
    Consumer() : m_buf(nullptr) {}
    Consumer(std::string&& id, Buffer<T> *buf) : m_id(id), m_buf(buf) {}

    void consume() {
        while(true) {
            T x = m_buf->remove();
            std::cout << x;

            int sleep = std::rand() % 1000 + 10;
            std::this_thread::sleep_for(std::chrono::milliseconds(sleep));
        }
    }

private:
    Buffer<T> *m_buf;
    std::string m_id;
};

int main(int argc, char const *argv[])
{
    std::srand(std::time(nullptr));

    Buffer<elem_t> *buffer = new Buffer<elem_t>(std::stoi(argv[1]));
    Producer<elem_t> *p = new Producer<elem_t>("prod", buffer);
    Consumer<elem_t> *c = new Consumer<elem_t>("cons", buffer);

    std::thread pt(&Producer<elem_t>::produce, p);
    std::thread ct(&Consumer<elem_t>::consume, c);

    pt.join();
    ct.join();

    return 0;
}
