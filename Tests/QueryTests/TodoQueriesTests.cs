using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.QueryTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>
            {
                new TodoItem("tarefa 1", "usuario A", DateTime.Now),
                new TodoItem("tarefa 2", "usuario A", DateTime.Now),
                new TodoItem("tarefa 3", "Andre", DateTime.Now),
                new TodoItem("tarefa 4", "usuario A", DateTime.Now),
                new TodoItem("tarefa 5", "Andre", DateTime.Now)
            };
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Andre"));
            Assert.AreEqual(2, result.Count());
        }
    }
}