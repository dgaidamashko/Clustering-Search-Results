#!/usr/bin/python
# -*- coding: utf-8 -*-
from grab import Grab
from django.utils.http import urlquote_plus
import logging
logger = logging.getLogger('grab')
logger.addHandler(logging.StreamHandler())
logger.setLevel(logging.DEBUG)
g=Grab()
g.setup(connect_timeout=20, timeout=20)
titles=[]
hrefs=[]
snippets=[]
group=1
query=input()
pages_many_links=[]
pages_many_titles=[]
pages_many_snippets=[]

def replacement(string):
    return string.replace('\u2014', '-').replace('\u0301', '').replace('\u2013', '-')
#page=group-1
page=0
while page<3:
    yandex_url = 'http://yandex.ru/yandsearch?text=%s&numdoc=50 ' % urlquote_plus(query)
    if page:
        yandex_url += '&p=%d' % page
    g.go(yandex_url)
    a=g.doc.select('//div[@class="serp-list" and @role="main"]/div[contains(@class,"serp-block serp-block-")]/div')
    k=a.selector_list
    page+=1
x=0