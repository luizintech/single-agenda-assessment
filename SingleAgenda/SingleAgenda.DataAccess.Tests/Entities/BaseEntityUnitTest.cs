using NUnit.Framework;
using SingleAgenda.Entities.Location;
using SingleAgenda.Entities.Base;
using SingleAgenda.Entities.Person;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace SingleAgenda.DataAccess.Tests.Entities
{

    /// <summary>
    /// Here I ensure some premisses for my database
    /// model and some rules that the tables need to
    /// implement.
    /// </summary>
    public class BaseEntityUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// For this test purposes, I defined the primary key
        /// like an Integer value.
        /// </summary>
        [Test]
        public void NeedsAPrimaryKeyandMustBeInteger()
        {
            TestThePrimaryKeyOfEntityModel(typeof(EntityBase));
            TestThePrimaryKeyOfEntityModel(typeof(Person));
            TestThePrimaryKeyOfEntityModel(typeof(NaturalPerson));
            TestThePrimaryKeyOfEntityModel(typeof(LegalPerson));
            TestThePrimaryKeyOfEntityModel(typeof(Address));
        }

        /// <summary>
        /// Here I hold the name of field to ensure that all tables has 
        /// the same structure. (CreatedAt)
        /// </summary>
        [Test]
        public void RequiresAtLeastOneFieldToControlCreateDate()
        {
            TestTheCreatedDateFieldRequirement(typeof(EntityBase));
            TestTheCreatedDateFieldRequirement(typeof(Person));
            TestTheCreatedDateFieldRequirement(typeof(NaturalPerson));
            TestTheCreatedDateFieldRequirement(typeof(LegalPerson));
            TestTheCreatedDateFieldRequirement(typeof(Address));
        }

        /// <summary>
        /// All my delete methods will be only logical exclusion. 
        /// For this, I'll set the field. (Removed)
        /// </summary>
        [Test]
        public void RequiresLogicalExcludeField()
        {
            TestTheLogicalExclusionRequirement(typeof(EntityBase));
            TestTheLogicalExclusionRequirement(typeof(Person));
            TestTheLogicalExclusionRequirement(typeof(NaturalPerson));
            TestTheLogicalExclusionRequirement(typeof(LegalPerson));
            TestTheLogicalExclusionRequirement(typeof(Address));
        }

        #region Private methods

        private static void TestThePrimaryKeyOfEntityModel(Type type)
        {
            var hasPrimaryKey = type.GetRuntimeProperties()
                 .Where(pi => pi.PropertyType == typeof(int)
                    && pi.GetCustomAttributes<KeyAttribute>(true).Any()).Any();

            Assert.IsTrue(hasPrimaryKey, "Define a primary key for the Entity.");
        }

        private static void TestTheCreatedDateFieldRequirement(Type type)
        {
            var datetimeFields = type.GetRuntimeProperties()
                             .Where(pi => pi.PropertyType == typeof(DateTime)).ToArray();

            var datetimeCreateField = false;
            foreach (var field in datetimeFields)
                datetimeCreateField = field.Name == "CreatedAt";

            Assert.IsTrue(datetimeCreateField, "You must implement a creation date field.");
        }

        private static void TestTheLogicalExclusionRequirement(Type type)
        {
            var logicalFields = type.GetRuntimeProperties()
                             .Where(pi => pi.PropertyType == typeof(bool)).ToArray();

            var removedField = false;
            foreach (var field in logicalFields)
                removedField = field.Name == "Removed";

            Assert.IsTrue(removedField, "You must include the Removed field.");
        }

        #endregion

    }
}