namespace LinkedLists
{
	internal partial class Program
	{
		static void Main(string[] args)
		{
			ListNode list = new([1,2,3,4,5]);
			Double(list).Print();
		}

		// 1
		static ListNode Merge(ListNode list1, ListNode list2)
		{
			ListNode resultHead = new()
			{
				Value = -1
			};
			ListNode resultPtr = resultHead;

			for (; list1 != null && list2 != null; resultPtr = resultPtr.Next)
			{
				if (list1.Value <= list2.Value)
				{
					resultPtr.Next = list1;
					list1 = list1.Next;
				}
				else
				{
					resultPtr.Next = list2;
					list2 = list2.Next;
				}
			}

			if (list1 != null)
				resultPtr.Next = list1;
			else
				resultPtr.Next = list2;

			return resultHead.Next;
		}

		// 2
		static ListNode DeleteDuplicates(ListNode list)
		{
			if (list == null)
				return list;

			ListNode node = list;
			while (node.Next != null)
			{
				if (node.Value == node.Next.Value)
				{
					ListNode ptr = node.Next;
					node.Next = ptr.Next;
				}
				else
					node = node.Next;
			}
			return list;
		}

		// 3
		bool IsCyclic(ListNode list)
		{
			ListNode turtle = list;
			ListNode rabbit = list;

			while (rabbit != null || rabbit.Next != null)
			{
				turtle = turtle.Next;
				rabbit = rabbit.Next.Next;
				if (turtle == rabbit) return true;
			}

			return false;
		}

		// 4
		static ListNode ReorderList(ListNode list)
		{
			ListNode slow = list;
			ListNode fast = list.Next;

			while (fast != null && fast.Next != null)
			{
				fast = fast.Next.Next;
				slow = slow.Next;
			}

			ListNode right = slow.Next;
			ListNode left = list;
			slow.Next = null;

			ListNode previous = null;
			ListNode current = right;
			while (current != null)
			{
				ListNode next = current.Next;
				current.Next = previous;
				previous = current;
				current = next;
			}

			right = previous;

			while (right != null)
			{
				ListNode leftTemp = left.Next;
				ListNode rightTemp = right.Next;
				left.Next = right;
				right.Next = leftTemp;

				left = leftTemp;
				right = rightTemp;
			}

			return list;
		}

		// 5
		static void DeleteNode(ListNode? node)
		{
			if (node == null)
				return;

			node.Value = node.Next?.Value;
			node.Next = node.Next?.Next;
		}

		//6 
		static ListNode Double(ListNode list)
		{
			ListNode currentNode = list;
			ListNode previousNode = null;

			if (currentNode.Value * 2 > 9)
			{
				previousNode = new ListNode(0, currentNode);
				list = previousNode;
			}

			while (currentNode != null)
			{
				currentNode.Value *= 2;

				if (currentNode.Value > 9)
				{
					previousNode.Value += 1;
					currentNode.Value %= 10;
				}

				previousNode = currentNode;
				currentNode = currentNode.Next;
			}

			return list;
		}
	}
}
