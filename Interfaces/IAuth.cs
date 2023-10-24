namespace Hotel.Interfaces;
//TODO: интерфейсы лучше помещать рядом с их имплементациями, да и в целом по папкам распихивать всё, что требуется для конкретной задачи
public interface IAuth
{
    public string Login(string login, string password);
}
