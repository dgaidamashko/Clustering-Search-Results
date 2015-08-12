__author__ = 'user'
from grab import Grab

g = Grab()
g.go('google.ru')

# вбиваем запрос 'grab python' в строку поиска (name='q')
g.doc.set_input('q', 'grab python')
# нажимаем кнопку - поиск
g.doc.submit(submit_name='btnG')
# используем селектор с выражениями xpath
for y in g.doc.select(".//h3[@class = 'r']//a"):
    print(y.text())
    print(y.attr('href'))
    # print (y.html())