using System;
using Domain.Commands;
using Domain.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Repositories;

namespace Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        
        
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand();
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo","AndreBalta", DateTime.Now);
        private readonly FakeTodoRepository _reporitory = new FakeTodoRepository();
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        [TestMethod]
        public void Dado_um_commando_invalido_deve_interromper_a_execucao()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(false, result.Success);
        }
        
        [TestMethod]
        public void Dado_um_commando_valido_deve_criar_a_tarefa()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(true, result.Success);
        }
       
    }
}