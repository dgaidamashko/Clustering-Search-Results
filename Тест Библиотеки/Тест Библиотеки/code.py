import Stemmer
while 1>0:
    stemmer = Stemmer.Stemmer(input())
    stemmed = stemmer.stemWords(input().split())
    print(' '.join([str(elem) for elem in stemmed]))

