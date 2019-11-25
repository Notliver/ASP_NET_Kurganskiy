namespace ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces
{
    /// <summary>
    /// Упорядоченная сущность
    /// </summary>
    public interface IOrderedEntity : IBaseEntity
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        int Order { get; set; }
    }



}
