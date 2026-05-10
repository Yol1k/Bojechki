using Bojechki_server.Database;
using System;


namespace Bojechki_server.Commands
{
    public class LoggerDecoratorCommand : ICommand
    {
        private readonly ICommand _inner;

        public LoggerDecoratorCommand(ICommand inner) => _inner = inner;

        public string Execute(AppDbContext db, string[] parts)
        {
            var commandName = _inner.GetType().Name;
            Console.WriteLine($"[ЛОГ] Выполняется команда: {commandName}");
            Console.WriteLine($"[ЛОГ] Параметры: {string.Join("|", parts)}");
            var start = DateTime.Now;

            try
            {
                var result = _inner.Execute(db, parts);
                var duration = DateTime.Now - start;
                Console.WriteLine($"[ЛОГ] Команда выполнена успешно за {duration.TotalMilliseconds} мс. Длина ответа: {result.Length} символов");
                return result;
            }
            catch (Exception ex)
            {
                var duration = DateTime.Now - start;
                Console.WriteLine($"[ЛОГ] ОШИБКА при выполнении команды {commandName} через {duration.TotalMilliseconds} мс");
                Console.WriteLine($"[ЛОГ] Исключение: {ex.Message}");
                Console.WriteLine($"[ЛОГ] Стек: {ex.StackTrace}");
                return $"ERROR|{ex.Message}";
            }
        }
    }
}