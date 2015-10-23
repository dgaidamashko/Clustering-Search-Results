#!/usr/bin/python
# -*- coding: utf-8 -*-
from grab import Grab
from grab.proxylist import ProxyList
from django.utils.http import urlquote_plus
import logging
logger = logging.getLogger('grab')
logger.addHandler(logging.StreamHandler())
logger.setLevel(logging.DEBUG)
g=Grab()
g.setup(connect_timeout=5, timeout=20)

titles=[]
hrefs=[]
snippets=[]
group=1
query=input()

def replacement(string):
    return string.replace('\u2014', '-').replace('\u0301', '').replace('\u2013', '-')
#page=group-1
page=0
while page<4:
    yandex_url = 'http://yandex.ru/yandsearch?text=%s&numdoc=100' % urlquote_plus(query)
    if page:
        yandex_url += '&p=%d' % page
    g.go(yandex_url)
    a = g.doc.select('//div[@class="serp-list" and @role="main"]/div[contains(@class,"serp-block serp-block") and not(contains(@class,"images")) and not(contains(@class,"video"))]//h2[@class="serp-item__title"]/a/@href')
    a1 = g.doc.select('//div[@class="serp-list" and @role="main"]/div[contains(@class,"serp-block serp-block") and not(contains(@class,"images")) and not(contains(@class,"video"))]//h2[@class="serp-item__title"]')
    a2 = g.doc.select('//div[@class="serp-list" and @role="main"]/div[contains(@class,"serp-block serp-block") and not(contains(@class,"images")) and not(contains(@class,"video"))]//div[contains(@class,"__text") or contains(@class,"__descr")]')
    for i in a.selector_list:
        hrefs.append(i._node)
    for i in a1.selector_list:
        titles.append(replacement(i.text()))
    for i in a2.selector_list:
        snippets.append(replacement(i.text()))
    page+=1
x=0
