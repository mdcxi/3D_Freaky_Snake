
namespace FreakySnake.Helpers
{
    namespace Message
    {
        public class MessageSystem
        {
            public enum MessageType
            {
                Damaged,
                Dead
            }
            
            public interface IMessageReceiver
            {
                void OnReceiveMessage(MessageType type, object sender, object message);
            }
        }
    }

}

