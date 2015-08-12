__author__ = 'daniil.gajdamashko'
import Stemmer
while 0<1:
    stemmer = Stemmer.Stemmer('russian')
    #print(stemmer.stemWord(input()))
    print(' '.join([str(elem) for elem in stemmer.stemWords(input().split())]))
