# API для управления задачами
API позволяет производить действия с задачами: просмотр, добавление, изменение, удаление.

## Описание API

### Получить список задач
`GET: api/ToDo`

**Ответ**: json строка вида:
```json
[{"id":0,"text":"Текст задачи 0"},{"id":1,"text":"Текст задачи 1"}]
```

### Получить Json объект с иформацией о задаче по id
`GET: api/ToDo/{id}`

**Ответ**: json строка вида:
```json
{"id":0,"text":"Текст задачи"}
```

### Добавить задачу
`POST: api/ToDo`

**Параметры:** *text* - текст задачи

**Ответ**: статус код *200*

### Изменить текст задачи по id
`PUT: api/ToDo/{id}`

**Параметры:** *text* - новый текст задачи

**Ответ**: статус код *200*

### Удалить задачу по id
`DELETE: api/ToDo/{id}`

**Ответ**: статус код *200*

