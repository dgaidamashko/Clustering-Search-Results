from django.db import models

# Create your models here.

class SearchResult(models.Model):
    title = models.CharField(max_length=200)
    url = models.URLField(max_length=200)
    snippet = models.TextField()

    def __str__(self):
        return self.title

class ClusterTags(models.Model):
    ClusterId = models.IntegerField()
    tag = models.CharField(max_length=20)

class ClusterSearchResult(models.Model):
    ClusterId = models.IntegerField
    cont = models.ManyToManyField(SearchResult)

