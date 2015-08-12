# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models, migrations


class Migration(migrations.Migration):

    dependencies = [
        ('Site', '0002_auto_20150623_2349'),
    ]

    operations = [
        migrations.CreateModel(
            name='ClusterContent',
            fields=[
                ('id', models.AutoField(verbose_name='ID', auto_created=True, primary_key=True, serialize=False)),
                ('cont', models.ManyToManyField(to='Site.SearchResult')),
            ],
        ),
        migrations.CreateModel(
            name='ClusterTags',
            fields=[
                ('id', models.AutoField(verbose_name='ID', auto_created=True, primary_key=True, serialize=False)),
                ('Cid', models.IntegerField()),
                ('tag', models.ManyToManyField(to='Site.Tag')),
            ],
        ),
        migrations.RemoveField(
            model_name='cluster',
            name='tags',
        ),
        migrations.RemoveField(
            model_name='cluster',
            name='text',
        ),
        migrations.DeleteModel(
            name='Cluster',
        ),
    ]
