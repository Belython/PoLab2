package ru.billing.client;

import ru.billing.exceptions.CatalogLoadException;
import ru.billing.stocklist.ItemCatalog;

public interface CatalogLoader
{
    public void load(ItemCatalog item) throws CatalogLoadException;
}
