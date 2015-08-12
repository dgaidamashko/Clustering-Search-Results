from grab import Grab

g = Grab()
#g.go('https://www.google.ru/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=grab%20python')
# g.go("https://www.google.ru/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=%D0%BC%D0%B8%D1%80%D0%BE%D0%BD%D0%BE%D0%B2")
# g.go("http://google.com/")
# g.go("https://www.google.com/search?q=%D0%BC%D0%B8%D1%80%D0%BE%D0%BD%D0%BE%D0%B2&ie=utf-8&oe=utf-8")

#Firefox Миронов
g.go("https://www.google.ru/?gfe_rd=cr&ei=6YK_VYHpEovFtAHGpoWYCA&gws_rd=ssl#newwindow=1&q=%D0%BC%D0%B8%D1%80%D0%BE%D0%BD%D0%BE%D0%B2")


y = None
# вбиваем запрос 'grab python' в строку поиска (name='q')
# g.doc.set_input('q', 'grab python')
# нажимаем кнопку - поиск
# g.doc.submit(submit_name='btnG')
# используем селектор с выражениями xpath
# a=g.doc.select("//class = 'r'/text()")
# a = g.doc.select("//title/text()")
a = g.doc.select(".//*[@id='rso']/div[2]/div[3]/div/div/div/span")
# a = g.doc.select("//*[@id='rso']/div[2]")
# a=g.doc.select("//body")
# a=g.doc.rex_text('<h3 class="r">([^>]+)</h3>')
for listelem in a:
    print(listelem.text())
    
    
#for y in g.doc.select("//h3 class='r'/text()"):
 #   print(y.text())
  #  print(y.attr('href'))
    # print (y.html())
