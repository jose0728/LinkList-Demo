using System;
using System.Collections.Generic;
using System.Text;

namespace LinkListDemo
{
    public class ListDemo
    {
        public Node header;  //头结点
        public ListDemo()
        {
            header = new Node();  //构造头结点
        }

        /// <summary>
        /// 查找某一节点
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Node Find(string str)
        {
            Node current = header;
            while (current != null && current.item != str)
            {
                //如果当前节点不为空
                current = current.next;
            }
            return current;  //返回当前节点
        }

        /// <summary>
        /// 查找某一节点的上一个节点
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private Node FindPre(string str)
        {
            Node current = header;
            while (current.next != null && current.next.item != str)
            {
                //如果当前节点不为空
                current = current.next;
            }
            return current;  //返回当前节点
        }

        /// <summary>
        /// 打印链表
        /// </summary>
        public void Print()
        {
            //Node current = header;//打印首元结点
            Node current = header.next;
            while (current != null)
            {
                Console.WriteLine(current.item);
                current = current.next;
            }
        }

        /// <summary>
        /// 在after数据后面插入data
        /// </summary>
        /// <param name="str"></param>
        /// <param name="after"></param>
        public void Insert(string data, string after)
        {
            Node afterNode = Find(after);
            if (afterNode == null)
            {
                Console.WriteLine("没有找到前节点,无法完成插入操作");
                return;
            }

            Node needToInsert = new Node(data);
            needToInsert.next = afterNode.next;
            afterNode.next = needToInsert;

        }

        /// <summary>
        /// 移除某个节点
        /// </summary>
        /// <param name="data"></param>
        public void Remove(string data)
        {
            Node preNode = FindPre(data);
            if (preNode == null)
            {
                Console.WriteLine("没有找到前节点,无法完成移除操作");
                return;
            }

            preNode.next = preNode.next.next;
        }

        /// <summary>
        /// 反转链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public void ReverseList(Node head)
        {
            if (head == null || head.next == null)
            {
                return;
            }

            Node p1 = head;
            Node p2 = head.next;
            Node p3 = null;

            while (p2 != null)
            {
                p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
            }
            head.next = null;
            header.next = p1;
        }

        /// <summary>
        /// 单向链表的中间节点（快慢指针法）
        /// </summary>
        /// <param name="L"></param>
        public void GetMidNode(Node L)
        {
            Node fast = L, slow = L;
            while (fast != null)
            {
                if (fast.next == null)
                {
                    break;
                }
                fast = fast.next.next;
                slow = slow.next;
            }
            Console.WriteLine("中间节点" + slow.item);
        }
    }

    public class Node
    {
        public string item;  //数据
        public Node next;  //指针

        public Node()
        {
            item = "header";  //创建节点
            next = null;
        }

        public Node(string str)
        {
            item = str;  //使用指定字符构建节点
            next = null;
        }
    }
}
