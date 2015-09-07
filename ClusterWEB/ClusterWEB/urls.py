#!/usr/bin/python
# -*- coding: utf-8 -*-
"""ClusterWEB URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/1.8/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  url(r'^$', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  url(r'^$', Home.as_view(), name='home')
Including another URLconf
    1. Add an import:  from blog import urls as blog_urls
    2. Add a URL to urlpatterns:  url(r'^blog/', include(blog_urls))
"""
from django.conf.urls import patterns, url
from Site import views

urlpatterns = patterns('', url(r'^$', views.main_page_runserver),
                       url(r'^search/$', views.main_page),
                       url(r'\?search_request=(?P<search_request>.*)$', views.search_page_redirect),
                       url(r'^search/results/request=(?P<search_request>.*)&group=(?P<group>\d+)/$',
                           views.search_page))

# urlpatterns = patterns('', url(r'^$', views.main_page),
# url(r' ^results/search=(?P<search_string>)\d/group=(?P<group_num>\d+)/$', views.result_page()))
