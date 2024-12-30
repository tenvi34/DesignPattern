namespace VisitorPattern
{
    // Element 인터페이스
    public interface IBikeElement
    {
        void Accept(IVisitor visitor);
    }
}