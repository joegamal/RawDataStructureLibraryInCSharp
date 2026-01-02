using System.Collections.Generic;


namespace RawDataStructure;


public class Node<T>
{
	public T Value;

	public Node<T> next;

	public Node(T val)
	{
		next = null;

		this.Value = val;
	}
		
}

public class LinkedList<T>
{
	public int Count;


	public Node<T> head;

	public Node<T> tail;


	public LinkedList()
	{
		Count = 0;

		head = tail = null;

	}


	public void Add(T value)
	{
		if (Count == 0)
		{
			Node<T> val = new Node<T>(value);
		
			head = val;

			tail = val;
		}
        else
        {
			tail.next = new Node<T> (value);
			tail = tail.next;
        }


        Count++;
	}

	public bool Exist(T val)
	{
		Node<T> currnet_node = head;
        while(currnet_node != null)
		{
			if(EqualityComparer<T>.Default.Equals(currnet_node.Value, val))
			{
				return true;
			}
			currnet_node = currnet_node.next;
		}

		return false;
    }

	public void Remove(T value)
	{
		if(Count == 0 || head == null) { return; }

		Node<T> currnet_node = head.next;
		Node<T> _node = head;


		if(EqualityComparer<T>.Default.Equals(head.Value, value))
		{
			head = head.next;
			if (Count == 1) { tail = null; }
			Count--;

			return;
		}


		while (currnet_node != null)
		{


			if (EqualityComparer<T>.Default.Equals(currnet_node.Value, value))
			{
				//means this is the tail
				if(currnet_node.next == null)
				{
					tail = _node;

					Count--;

					_node.next = null;

					return;
				}

				_node.next = currnet_node.next;
					
				Count--;

				return;
			}
			_node = currnet_node;
			currnet_node = currnet_node.next;
		}

	}

	public void Reverse()
	{
		if(head == null || Count <= 1) { return; }

		Node<T> _current = head.next;
		Node<T> _next = _current.next;
		Node<T> _prev = head;
		head.next = null;

		while(_next != null)
		{
			
			_current.next = _prev;

			_prev = _current;

			_current = _next;

			_next = _next.next;


		}

		_current.next = _prev;

		Node<T> dummy = head;

		head = tail;

		tail = dummy;

		return;
	}
}
