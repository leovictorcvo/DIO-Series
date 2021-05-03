using Console_in_memory_repository.Data;
using Console_in_memory_repository.Entities;
using Console_in_memory_repository.Enums;
using System;
using Xunit;

namespace Console_in_memory_repository_test
{
    public class SeriesRepositoryHelper: IDisposable
    {
        SeriesRepository repository;
        public SeriesRepositoryHelper()
        {
            repository = SeriesRepository.GetInstance();
        }

        public void Dispose()
        {
            repository.ClearAll();
        }

        [Fact]
        public void ShouldReturnEmptyListWhenNoSeriesIsRecorded()
        {
            var list = repository.getAll();
            Assert.Empty(list);
        }

        [Fact]
        public void ShouldBeAbleToAddANewSerie()
        {
            var serie = new Series(1, "Test", ECategories.Acao, true);
            repository.Save(serie);
        }

        [Fact]
        public void ShouldReturnAllSeries()
        {
            var serie1 = new Series(1, "Test1", ECategories.Acao, true);
            var serie2 = new Series(1, "Test2", ECategories.Acao, true);

            repository.Save(serie1);
            repository.Save(serie2);
            var list = repository.getAll();

            Assert.Equal(2, list.Count);
            Assert.Equal(serie1, list[0]);
            Assert.Equal(serie2, list[1]);
        }

        [Fact]
        public void ShouldReturnNextIdToSave()
        {
            var firstId = repository.GetNextId();
            Assert.Equal(1, firstId);

            repository.Save(new Series(firstId, "Teste 1", ECategories.Acao, true));
            var secondId = repository.GetNextId();
            Assert.Equal(2, secondId);
        }

        [Fact]
        public void ShouldReturnASerieById()
        {
            var id = repository.GetNextId();
            var serie = new Series(id, "Test 1", ECategories.Acao, true);
            repository.Save(serie);

            var serieSaved = repository.getById(id);

            Assert.Equal(id, serieSaved.Id);
            Assert.Equal("Test 1", serieSaved.Name);
            Assert.Equal(ECategories.Acao, serieSaved.Category);
            Assert.True(serieSaved.Active);
        }

        [Fact]
        public void ShouldUpdateSeries()
        {
            var id = repository.GetNextId();
            var serie = new Series(id, "Test 1", ECategories.Acao, true);
            repository.Save(serie);

            var newSerie = new Series(id, "Test updated", ECategories.Aventura, true);
            repository.Update(id, newSerie);

            var serieSaved = repository.getById(id);

            Assert.Equal(id, serieSaved.Id);
            Assert.Equal("Test updated", serieSaved.Name);
            Assert.Equal(ECategories.Aventura, serieSaved.Category);
            Assert.True(serieSaved.Active);
        }

        [Fact]
        public void ShouldSetActiveFalseWhenRemove()
        {
            var id = repository.GetNextId();
            var serie = new Series(id, "Test 1", ECategories.Acao, true);
            repository.Save(serie);

            repository.Delete(id);

            var serieDeleted = repository.getById(id);

            Assert.Equal(id, serieDeleted.Id);
            Assert.Equal("Test 1", serieDeleted.Name);
            Assert.Equal(ECategories.Acao, serieDeleted.Category);
            Assert.False(serieDeleted.Active);
        }
    }
}
