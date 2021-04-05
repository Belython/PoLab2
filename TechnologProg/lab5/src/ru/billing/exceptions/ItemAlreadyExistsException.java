package ru.billing.exceptions;

public class ItemAlreadyExistsException extends Exception
{
    public ItemAlreadyExistsException(String message)
    {
        super(message);
    }
    public ItemAlreadyExistsException()
    {
        this("Ошибка загрузки товара");
    }
}
