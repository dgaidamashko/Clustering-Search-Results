import requests  
from lxml import html  
from urllib3 import * 
import collections

STARTING_URL = 'http://devacademy.ru/'

urls_queue = collections.deque()  
urls_queue.append(STARTING_URL)  
found_urls = set()  
found_urls.add(STARTING_URL)

while len(urls_queue):  
    url = urls_queue.popleft()

    response = requests.get(url)
    parsed_body = html.fromstring(response.content)

    # Печатает заголовок страницы
    print(parsed_body.xpath('//title/text()'))

    # Ищет все ссылки
    links = [urlparse.urljoin(response.url, url) for url in parsed_body.xpath('//a/@href')]
    for link in links:
        found_urls.add(link)

        # Добавить в очередь, только если ссылка HTTP/HTTPS
        if url not in found_urls and url.startswith('http'):
            urls_queue.append(link)
