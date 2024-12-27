namespace VisitorPattern
{
    public interface IBikeElement
    {
        void Accept(IVisitor visitor);
    }
}