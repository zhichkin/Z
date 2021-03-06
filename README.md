# 1C# (OneCSharp)
1C# - это платформа для разработки серверных приложений, доступных через web.

Развитие проекта: [DaJet QL - расширяемый язык запросов](https://infostart.ru/public/1226230/)
Примеры использования: [JSON в запросах DaJet QL](https://infostart.ru/public/1228025/)
Во второй версии реализована поддержка полного синтаксиса SQL Server 2005-2016.
Обращение к объектам СУБД также вполняется в терминах 1С аналогично EntitySQL.
[Репозиторий DaJet QL](https://github.com/zhichkin/one-c-sharp-sql)

1C# умеет работать с базами данных платформы 1С:Предприятие 7-ой и 8-ой версий напрямую.
Возможно также создание своих или работа с уже существующими базами данных "не 1С".

1C# состоит из трёх основных подсистем:

**1. Метаданные.**

Метаданные используются для моделирования прикладных объектов и их структур хранения данных.
Для работы с метаданными используется конфигуратор 1C# аналогичный конфигуратору 1С. Метаданные 1C# хранятся в базе данных SQL Server (см. инструкцию по установке).

**2. Дизайнер запросов.**

Визуальный конструктор запросов аналогичный Microsoft SQL Server Management Studio. Этот дизайнер обеспечивает визуальное редактирование запроса в терминах объектов метаданных 1С, а не названий таблиц СУБД. Результатом работы дизайнера является построение синтаксического дерева запроса, которое можно сохранить в дереве метаданных 1C#. Запрос, как объект метаданных, может быть вызван через web сервер 1C# для выполнения и получения результата.

1C# умеет обращаться к данным из разных источников в одном запросе. Например, можно создать запрос, который одновременно получает данные из 1С 7.7 + 1С 8.3 + база данных "не 1С". Такой запрос создаётся в терминах метаданных 1С 8-ой версии.

**3. Web сервер.**

Web сервер 1C# - это .NET Core middleware (внешняя компонента для web сервера).
Непосредственно в качестве web сервера используется Kestrel.
Web сервер 1C# обслуживает клиентские запросы к созданным в конфигураторе 1C# запросам данных.
Полученный результат запроса сериализуется и отдайтся клиенту в формате JSON.

# Установка

Требуется установка [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) + [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core)

Демо-версия программы [v0.1.0](https://github.com/zhichkin/one-c-sharp/releases/download/v0.1.0/one-c-sharp-demo-version.zip):

* **utilities** - скрипты SQL и обработки для выгрузки метаданных 1С в формате XML для загрузки в 1C#
  - **SQL** - каталог скриптов для создания базы данных 1C# на SQL Server
  - **ConfigurationExporter82.epf** - выгрузка метаданных 1С на обычных формах
  - **ConfigurationExporter83.epf** - выгрузка метаданных 1С на управляемых формах
* **web-server** - сервер 1C#, доступный по протоколу http
  - **web-server** - каталог исполняемых файлов сервера 1C#
  - **run-server.bat** - запуск сервера 1C#
  - **show-web-server-settings.bat** - просмотр и редактирование настроек сервера 1C# в notepad
    - appSettings\ServerURL - адрес и порт web сервера 1C#
    - connectionStrings\Zhichkin.Metadata - строка подключения к базе данных 1C#
* **wpf-ui** - конфигуратор 1C#
  - **wpf-ui** - каталог исполняемых файлов конфигуратора 1C#
  - **run-wpf-ui.bat** - запуск конфигуратора 1C#

1. Скачать и распаковать архив программы в каталог установки.
2. Запустить конфигуратор 1C#, будет запущен мастер создания и настройки базы данных 1C#.
3. Указать мастеру название сервера SQL Server, логин и пароль пользователя. Поле "Database name" оставить пустым.
4. Нажать кнопку "Setup". Будет создана база данных 1C#. Метаданные появятся в левой панели программы.
5. Настроить подключение к базе данных 1C# для web сервера 1C#, используя файл show-web-server-settings.bat.
6. Настроить адрес и порт web сервера 1C#, используя файл show-web-server-settings.bat.

Дополнительные подробности по установке 1C# можно найти в папке **docs** данного репозитория.

# Канал проекта на YouTube

| 1C# - идея проекта за 3 минуты | 1C# - быстрый старт |
|---|---|
|<a href="https://youtu.be/OsW-2OeAA00" target="_blank"><img src="https://img.youtube.com/vi/OsW-2OeAA00/mqdefault.jpg" alt="ALT-OneCSharp in 3 minutes" width="300" height="180" border="10" /></a>|<a href="https://youtu.be/TUu8-dQHwiA" target="_blank"><img src="https://img.youtube.com/vi/TUu8-dQHwiA/mqdefault.jpg" alt="ALT-OneCSharp - quick start" width="300" height="180" border="10" /></a>|

# Передача парметров web сервису 1C#

Передача параметров web функции 1C#, созданной при помощи конфигуратора платформы, выполняется в виде JSON объекта следующего вида:
```json
{
   "Булево" : true,
   "Строка" : "Тест",
   "ЦелоеЧисло" : 123,
   "ДробноеЧисло" : 123.45,
   "Дата" : "2019-08-01T19:15:00",
   "Неопределено" : null
}
```

# Контакты
dima_zhichkin@mail.ru
skype: dima.zhichkin
