#include <iostream>
#include <thread>
#include <vector>

int x = 0;

void thread_func()
{
    x++;
    std::this_thread::sleep_for(std::chrono::milliseconds(std::rand() % 100 + 10));
    x--;
}

int main(int argc, char const *argv[])
{
    std::srand(std::time(nullptr));

    int N = std::stoi(argv[1]);

    std::vector<std::thread> thr(N);

    for (int i = 0; i < N; i++) {
        std::thread t;
        thr[i] = std::move(t);
    }

    for (int i = 0; i < N; i++) {
        thr[i] = std::thread{thread_func};
    }

    for (auto& t : thr) {
        t.join();
    }

    std::cout << "DONE: " << x << std::endl;
    return 0;
}
