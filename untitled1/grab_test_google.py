__author__ = 'user'
from grab import Grab

g = Grab()
g.go('google.ru')

# ������� ������ 'grab python' � ������ ������ (name='q')
g.doc.set_input('q', 'grab python')
# �������� ������ - �����
g.doc.submit(submit_name='btnG')
# ���������� �������� � ����������� xpath
for y in g.doc.select(".//h3[@class = 'r']//a"):
    print(y.text())
    print(y.attr('href'))
    # print (y.html())