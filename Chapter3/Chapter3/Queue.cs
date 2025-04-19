public class Queue<T>
{
    private Node<T> first;
    private Node<T> last;

    public Queue()
    {
        this.first = null;
        this.last = null;
    }

    public void Insert(T x)
    {
        Node<T> temp = new Node<T>(x);
        if (first == null)
                first = temp;
        else
                last.SetNext( temp);
        last = temp;
    }

    public T Remove()
    {
        T x =  first.GetValue();    
        first = first.GetNext();
        if (first == null)
                last = null;
        return  x;
    }        

    public T Head()
    {
        return  first.GetValue();
    }

    public bool IsEmpty()
    {             
        return first == null;                 
    }

    // This method was added to use for printing Queue     
    public override string ToString()
    { 
        Node<T> current = first;
        string st = "Queue[";
        while (current != null) {
            st += current.ToString();                    
            current = current.GetNext();
            if (current != null)
                st += ",";
        }
        return st + "]";    
    }        
}
