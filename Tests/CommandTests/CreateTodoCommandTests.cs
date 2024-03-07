using System;
using Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand();
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo","AndreBalta", DateTime.Now);

        public CreateTodoCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Dado_Um_Commando_Invalido()
        {
            Assert.AreEqual(false, _invalidCommand.Valid);
        }
        
        [TestMethod]
        public void Dado_Um_Commando_Valido()
        {
            Assert.AreEqual(true, _validCommand.Valid);
        }
    }
}