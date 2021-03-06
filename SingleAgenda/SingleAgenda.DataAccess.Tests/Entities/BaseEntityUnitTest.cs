using NUnit.Framework;
using SingleAgenda.Entities.Base;
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
            var type = typeof(EntityBase);
            var hasPrimaryKey = type.GetRuntimeProperties()
                 .Where(pi => pi.PropertyType == typeof(int)
                    && pi.GetCustomAttributes<KeyAttribute>(true).Any()).Any();

            Assert.IsTrue(hasPrimaryKey, "Define a primary key for the Entity.");
        }

        /// <summary>
        /// Here I hold the name of field to ensure that all tables has 
        /// the same structure. (CreatedAt)
        /// </summary>
        [Test]
        public void RequiresAtLeastOneFieldToControlCreateDate()
        {
            var type = typeof(EntityBase);
            var datetimeFields = type.GetRuntimeProperties()
                 .Where(pi => pi.PropertyType == typeof(DateTime)).ToArray();

            var datetimeCreateField = false;
            foreach (var field in datetimeFields)
                datetimeCreateField = field.Name == "CreatedAt";

            Assert.IsTrue(datetimeCreateField, "You must implement a creation date field.");
        }

    }
}