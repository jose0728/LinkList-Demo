using System;
using System.Collections.Generic;

namespace LinkListDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Person.TestLinkList();

            ListDemo list = new ListDemo();
            list.Insert("jiajia1", "header");
            list.Insert("jiajia2", "jiajia1");
            list.Insert("jiajia3", "jiajia2");
            list.Insert("jiajia4", "jiajia3");
            list.Insert("jiajia5", "jiajia4");
            list.Print();
            Console.WriteLine("=============================");
            //list.Remove("jiajia4");
            list.ReverseList(list.Find("jiajia1"));
            list.Print();
            list.GetMidNode(list.Find("header"));
            Console.ReadKey();
        }
    }

    public class Person
    {
        public Person()
        {

        }
        public Person(string name, int age, string sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public void SayHi()
        {
            Console.WriteLine("我是{0},性别{1},今年{2}岁了!", this.Name, this.Sex, this.Age);
        }

        public static void TestLinkList()
        {
            LinkedList<Person> linkListPerson = new LinkedList<Person>();
            Person p = null;
            for (int i = 1; i < 10; i++)
            {
                p = new Person($"程序员{i}", i + 18, i % 5 == 1 ? "女" : "男");
                //添加
                linkListPerson.AddLast(p);
                //linkListPerson.AddFirst(p);               
            }

            Console.WriteLine($"新增的总人数:{linkListPerson.Count}");
            Console.WriteLine("-------------------------------------------------------------");


            //遍历
            LinkedListNode<Person> linkNodePerson = linkListPerson.First;
            linkNodePerson.Value.SayHi();

            while (linkNodePerson.Next != null)
            {
                linkNodePerson = linkNodePerson.Next;
                linkNodePerson.Value.SayHi();
            }

            Console.WriteLine("-------------------------------------------------------------");

            //删除
            while (linkNodePerson.Value != null && linkListPerson.Count > 0)
            {
                linkNodePerson = linkListPerson.Last;
                Console.Write($"当前总人数：{linkListPerson.Count}, 即将移除：{linkNodePerson.Value.Name} --> ");
                linkListPerson.RemoveLast();
                Console.WriteLine($"移除后总人数：{linkListPerson.Count}");
            }

        }
    }
}
