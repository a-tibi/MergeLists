using System;
using System.IO;

namespace mergeLists
{
	class Program
	{
		class SinglyLinkedListNode
		{
			public int data;
			public SinglyLinkedListNode next;

			public SinglyLinkedListNode(int nodeData)
			{
				this.data = nodeData;
				this.next = null;
			}
		}

		class SinglyLinkedList
		{
			public SinglyLinkedListNode head;
			public SinglyLinkedListNode tail;

			public SinglyLinkedList()
			{
				this.head = null;
				this.tail = null;
			}

			public void InsertNode(int nodeData)
			{
				SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

				if (this.head == null)
				{
					this.head = node;
				}
				else
				{
					this.tail.next = node;
				}

				this.tail = node;
			}
		}

		static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
		{
			while (node != null)
			{
				textWriter.Write(node.data);

				node = node.next;

				if (node != null)
				{
					textWriter.Write(sep);
				}
			}
		}

		static void PrintConsoleSinglyLinkedList(SinglyLinkedListNode node, string sep)
		{
			while (node != null)
			{
				Console.Write(node.data);

				node = node.next;

				if (node != null)
				{
					Console.Write(sep);
				}
			}
		}

		static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
		{
			SinglyLinkedList singlyLinkedList = new SinglyLinkedList();

			//bool end = false;
			var value1 = head1;
			var value2 = head2;
			while (!ReferenceEquals(value1, null) || !ReferenceEquals(value2, null))
			{
				if (ReferenceEquals(value1, null))
				{

					singlyLinkedList.tail.next = value2;
					return singlyLinkedList.head;
				}
				else if (ReferenceEquals(value2, null))
				{
					singlyLinkedList.tail.next = value1;
					return singlyLinkedList.head;
				}
				else
				{
					if (value1.data.CompareTo(value2.data) <= 0) // v1 <= v2
					{
						singlyLinkedList.InsertNode(value1.data);
						value1 = value1.next;
					}
					else
					{
						singlyLinkedList.InsertNode(value2.data);
						value2 = value2.next;
					}
				}
			}

			return singlyLinkedList.head;
		}

		static void Main(string[] args)
		{
			//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

			int tests = Convert.ToInt32(Console.ReadLine());

			for (int testsItr = 0; testsItr < tests; testsItr++)
			{
				SinglyLinkedList llist1 = new SinglyLinkedList();

				int llist1Count = Convert.ToInt32(Console.ReadLine());

				for (int i = 0; i < llist1Count; i++)
				{
					int llist1Item = Convert.ToInt32(Console.ReadLine());
					llist1.InsertNode(llist1Item);
				}

				SinglyLinkedList llist2 = new SinglyLinkedList();

				int llist2Count = Convert.ToInt32(Console.ReadLine());

				for (int i = 0; i < llist2Count; i++)
				{
					int llist2Item = Convert.ToInt32(Console.ReadLine());
					llist2.InsertNode(llist2Item);
				}

				SinglyLinkedListNode llist3 = mergeLists(llist1.head, llist2.head);

				//PrintSinglyLinkedList(llist3, " ", textWriter);
				//textWriter.WriteLine();
				PrintConsoleSinglyLinkedList(llist3, " ");
				Console.WriteLine();
			}

			//textWriter.Flush();
			//textWriter.Close();
		}
	}
}
