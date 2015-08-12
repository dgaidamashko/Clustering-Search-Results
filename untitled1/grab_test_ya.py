__author__ = 'user'
from grab import Grab
g = Grab()
words = 'grab, python'
lst = []
url = 'http://yandex.ru/yandsearch?rstr=-213&p={0}&text={1}'
param = words.replace(" ", "").split(',')
param2 = '%2C+'.join(str(elem) for elem in param)
with open('somefile.txt', 'wt') as f:
    for page in range(3):
        fullurl = url.format(page, param2)
        g.go(fullurl)
        for i in g.doc.select('//a[@class="b-link serp-item__title-link serp-item__title-link"]'):
            if g.doc.select('//a[@class="b-link serp-item__title-link serp-item__title-link"]').exists():
                lst.append({'page': page+1, 'title': i.text(), 'url': i.attr('href')})
                f.write(i.attr('href'))
                f.write('\n')
print(lst)