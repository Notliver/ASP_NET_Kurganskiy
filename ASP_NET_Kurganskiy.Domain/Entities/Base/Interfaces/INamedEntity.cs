namespace ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces
{
    /// <summary>
    /// Именованная сущность
    /// </summary>
    public interface INamedEntity : IBaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; set; }
    }



}
