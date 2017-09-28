import numpy as np
import matplotlib.pyplot as plt
from sklearn import linear_model

HOUSE_PRICES = [245, 312, 279, 308, 199, 219, 405, 324, 319, 255]
HOUSE_SIZES = [1400, 1600, 1700, 1875, 1100, 1550, 2350, 2450, 1425, 1700]

def graph(formula, x_range):
    X = np.array(x_range)
    Y = eval(formula)
    plt.plot(X, Y)

def plot_data(xs, ys, x_label, y_label):
    plt.scatter(xs, ys, color='black')
    plt.xlabel(x_label)
    plt.ylabel(y_label)
    plt.show()

def fit_model(xs, ys):
    arr_xs = np.array(xs).reshape((-1, 1))
    regr = linear_model.LinearRegression()
    regr.fit(arr_xs, ys)

    return regr


if __name__ == '__main__':
    regr = fit_model(HOUSE_SIZES, HOUSE_PRICES)
    graph('regr.coef_*X + regr.intercept_', range(1000, 2700)) 
    plot_data(HOUSE_SIZES, HOUSE_PRICES, 'sizes', 'prices')
