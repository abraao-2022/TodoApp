using System;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        public TodoItemTests()
        {
        }

        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            var todo = new TodoItem("dale","dale", DateTime.Now);
            Assert.AreEqual(false, todo.Done);
        }
    }
}