from django.db import models

# Create your models here.

class SearchResult(models.Model):
    title = models.CharField(max_length=200)
    url = models.URLField(max_length=200)
    snippet = models.TextField()
    # content = models.ForeignKey(Content)

    def __str__(self):
        return self.title


class Content(models.Model):
    content = models.TextField()

    def __str__(self):
        return self.content


class Tag(models.Model):
    title = models.CharField(max_length=20)

    def __str__(self):
        return self.title


class ClusterTags(models.Model):
    ClusterId = models.IntegerField()
    tag = models.ManyToManyField(Tag)


class ClusterContent(models.Model):
    ClusterId = models.IntegerField
    cont = models.ManyToManyField(SearchResult)


class Request(models.Model):
    title = models.CharField(max_length=40)

    def __str__(self):
        return self.title


class StandWebSearchers(models.Model):
    title = models.CharField(max_length=10)
    url = models.URLField(max_length=200)

    def __str__(self):
        return self.title

