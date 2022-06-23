using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Identifiers.Directors;

namespace PCC.Identifiers.Test.Builders
{
    [TestClass]
    public class PccStringVariableBuilderTest
    {
        private PccVariableDirector _director;

        [TestInitialize]
        public void Initialize()
        {
            _director = new PccVariableDirector();
        }

        [TestMethod]
        public void StringVariableCantBeNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccStringVariable);
            Assert.AreEqual(pccStringVariable.Id, 10);
            Assert.AreEqual(pccStringVariable.IdParent, 1);
            Assert.AreEqual(pccStringVariable.Name, "variable");
            Assert.AreEqual(pccStringVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccStringVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccStringVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccStringVariable.Type, PccIdentifierType.STRING);
            Assert.AreEqual(pccStringVariable.Class, PccIdentifierClass.VARIABLE);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Id' field of identifier should be a value greater than zero.")]
        public void StringVariableHaveAnIdLessThanZero()
        {
            long id = -1;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        public void IdParentOfStringVariableIsNull()
        {
            long id = 1;
            long? idParent = null;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccStringVariable);
            Assert.AreEqual(pccStringVariable.Id, 1);
            Assert.AreEqual(pccStringVariable.IdParent, null);
            Assert.AreEqual(pccStringVariable.Name, "variable");
            Assert.AreEqual(pccStringVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccStringVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccStringVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccStringVariable.Type, PccIdentifierType.STRING);
            Assert.AreEqual(pccStringVariable.Class, PccIdentifierClass.VARIABLE);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "If 'IdParent' field of identifier is not null, it should be a value greater than zero.")]
        public void StringVariableHaveAnIdParentLessThanZero()
        {
            long id = 1;
            long idParent = -1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0A";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'IdParent' field of identifier can't be equals to " +
            "'Id' field. The son variable should be different of parent variable.")]
        public void IdCantBeEqualsToIdParent()
        {
            long id = 1;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0A";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value.")]
        public void StringVariableNameIsNull()
        {
            long id = 1;
            long idParent = 10;
            string name = null;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value")]
        public void StringVariableNameIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = string.Empty;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void StringVariableHaveAnInitialPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = -1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void StringVariableHaveAFinalPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = -1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void StringVariableHaveAnInitialPositionGreaterThanFinalPositionTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 2;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Scope' of identifier is undefined.")]
        public void StringVariableScopeIsUndefined()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.UNDEFINED;
            string value = "Text";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }


        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void StringVariableValueIsNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = null;

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccStringVariable);
            Assert.AreEqual(pccStringVariable.Id, 10);
            Assert.AreEqual(pccStringVariable.IdParent, 1);
            Assert.AreEqual(pccStringVariable.Name, "variable");
            Assert.AreEqual(pccStringVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccStringVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccStringVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccStringVariable.Type, PccIdentifierType.STRING);
            Assert.AreEqual(pccStringVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccStringVariable.GetValueInStringFormat()));
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void StringVariableValueIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = string.Empty;

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccStringVariable);
            Assert.AreEqual(pccStringVariable.Id, 10);
            Assert.AreEqual(pccStringVariable.IdParent, 1);
            Assert.AreEqual(pccStringVariable.Name, "variable");
            Assert.AreEqual(pccStringVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccStringVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccStringVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccStringVariable.Type, PccIdentifierType.STRING);
            Assert.AreEqual(pccStringVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccStringVariable.GetValueInStringFormat()));
        }

        [TestMethod]
        public void StringVariableHasALargeValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                "labore et dolore magna aliqua.Nunc scelerisque viverra mauris in aliquam sem fringilla ut morbi.Viverra " + 
                "suspendisse potenti nullam ac tortor vitae purus faucibus ornare.Senectus et netus et malesuada. In eu " + 
                "mi bibendum neque egestas congue quisque egestas diam. Purus viverra accumsan in nisl nisi scelerisque " + 
                "eu ultrices vitae. Nisl nunc mi ipsum faucibus vitae aliquet.A pellentesque sit amet porttitor.Eu sem " + 
                "integer vitae justo eget magna fermentum. Mauris pharetra et ultrices neque.Magna sit amet purus gravida " + 
                "quis blandit.Leo urna molestie at elementum eu facilisis sed odio.Volutpat sed cras ornare arcu dui.";

            // Second Paragraph
            value += "Amet porttitor eget dolor morbi non arcu risus. Neque sodales ut etiam sit.Sit amet nisl purus " +
                "in mollis nunc. Enim neque volutpat ac tincidunt vitae semper.Laoreet id donec ultrices tincidunt arcu " +
                "non sodales. Faucibus vitae aliquet nec ullamcorper sit amet risus nullam eget. Quis auctor elit sed " +
                "vulputate mi sit amet mauris commodo. Posuere morbi leo urna molestie at elementum eu facilisis.Sit " +
                "amet cursus sit amet dictum. At in tellus integer feugiat scelerisque varius morbi. Non pulvinar neque " +
                "laoreet suspendisse interdum consectetur.Donec adipiscing tristique risus nec.Vel elit scelerisque mauris " +
                "pellentesque pulvinar pellentesque.Nisl purus in mollis nunc sed id semper risus.";

            // Third Paragraph
            value += "Etiam erat velit scelerisque in dictum non consectetur a. Vel quam elementum pulvinar etiam non " + 
                "quam lacus suspendisse.Euismod lacinia at quis risus sed vulputate odio ut enim. In nisl nisi scelerisque " + 
                "eu ultrices. Faucibus interdum posuere lorem ipsum dolor sit amet consectetur adipiscing. Sem fringilla ut " + 
                "morbi tincidunt augue interdum velit euismod.Eget duis at tellus at urna condimentum.Felis eget nunc lobortis " + 
                "mattis aliquam faucibus purus. Consequat mauris nunc congue nisi vitae suscipit tellus. Nec ultrices dui sapien " + 
                "eget.Elementum pulvinar etiam non quam lacus suspendisse.Malesuada fames ac turpis egestas sed tempus urna " + 
                "et.Purus sit amet luctus venenatis lectus magna fringilla urna porttitor. Faucibus et molestie ac feugiat " + 
                "sed lectus vestibulum mattis ullamcorper. Malesuada nunc vel risus commodo viverra maecenas.Malesuada bibendum " + 
                "arcu vitae elementum.";

            PccStringVariable pccStringVariable = _director.BuildStringVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsTrue(pccStringVariable.GetValueInStringFormat().Contains("Lorem ipsum dolor sit amet, consectetur " +
                "adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Nunc scelerisque " +
                "viverra mauris in aliquam sem fringilla ut morbi.Viverra suspendisse potenti nullam ac tortor vitae purus " +
                "faucibus ornare.Senectus et netus et malesuada. In eu mi bibendum neque egestas congue quisque egestas " +
                "diam. Purus viverra accumsan in nisl nisi scelerisque eu ultrices vitae. Nisl nunc mi ipsum faucibus " +
                "vitae aliquet.A pellentesque sit amet porttitor.Eu sem integer vitae justo eget magna fermentum. Mauris " +
                "pharetra et ultrices neque.Magna sit amet purus gravida quis blandit.Leo urna molestie at elementum eu " +
                "facilisis sed odio.Volutpat sed cras ornare arcu dui."));

            Assert.IsTrue(pccStringVariable.GetValueInStringFormat().Contains("Amet porttitor eget dolor morbi non arcu " +
                "risus. Neque sodales ut etiam sit.Sit amet nisl purus in mollis nunc. Enim neque volutpat ac tincidunt " + 
                "vitae semper.Laoreet id donec ultrices tincidunt arcu non sodales. Faucibus vitae aliquet nec ullamcorper " + 
                "sit amet risus nullam eget. Quis auctor elit sed vulputate mi sit amet mauris commodo. Posuere morbi leo " + 
                "urna molestie at elementum eu facilisis.Sit amet cursus sit amet dictum. At in tellus integer feugiat " + 
                "scelerisque varius morbi. Non pulvinar neque laoreet suspendisse interdum consectetur.Donec adipiscing " + 
                "tristique risus nec.Vel elit scelerisque mauris pellentesque pulvinar pellentesque.Nisl purus in mollis " + 
                "nunc sed id semper risus."));

            Assert.IsTrue(pccStringVariable.GetValueInStringFormat().Contains("Etiam erat velit scelerisque in dictum non " +
                "consectetur a. Vel quam elementum pulvinar etiam non quam lacus suspendisse.Euismod lacinia at quis risus " + 
                "sed vulputate odio ut enim. In nisl nisi scelerisque eu ultrices. Faucibus interdum posuere lorem ipsum " + 
                "dolor sit amet consectetur adipiscing. Sem fringilla ut morbi tincidunt augue interdum velit euismod.Eget " + 
                "duis at tellus at urna condimentum.Felis eget nunc lobortis mattis aliquam faucibus purus. Consequat " + 
                "mauris nunc congue nisi vitae suscipit tellus. Nec ultrices dui sapien eget.Elementum pulvinar etiam non " + 
                "quam lacus suspendisse.Malesuada fames ac turpis egestas sed tempus urna et.Purus sit amet luctus venenatis " +
                "lectus magna fringilla urna porttitor. Faucibus et molestie ac feugiat sed lectus vestibulum mattis " + 
                "ullamcorper. Malesuada nunc vel risus commodo viverra maecenas.Malesuada bibendum arcu vitae elementum."));
        }
    }
}
