using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Спортивный_клуб;
using Спортивный_клуб.Классы;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
            ListBox listBox = new ListBox();
            events events = new events();
            events.Event(listBox);
        }

        [TestMethod]
        public void TestMethod1()
        {
            TextBox textBox = new TextBox();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();
            search search = new search();
            search.SearchAb(textBox,textBox1,textBox2,textBox3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Абонемент абонемент = new Абонемент();
            абонемент.Save();
        }

        [TestMethod]
        public void TestMethod3()
        {
            Абонемент абонемент = new Абонемент();
            абонемент.Saver();
        }

        [TestMethod]
        public void TestMethod4()
        {
            ListBox listBox2 = new ListBox();
            subscription subscription = new subscription();
            subscription.Subscription(listBox2);
        }

        [TestMethod]
        public void TestMethod5()
        {
            ListBox listBox3 = new ListBox();
            appointments appointments = new appointments();
            appointments.Appointment(listBox3);
        }
    }
}
