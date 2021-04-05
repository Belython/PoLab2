import com.javatunes.util.ItemDAO;
import com.javatunes.util.MusicItem;

import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class ItemDAOMain
{
    public static void main(String[] args) throws ClassNotFoundException, SQLException {
        MusicItem item = new MusicItem();
        Connection conn = null;
        Class.forName("org.apache.derby.jdbc.ClientDriver");
        conn = DriverManager.getConnection("jdbc:derby://localhost:1527/JavaTunesDB");
        ItemDAO itemDAO = new ItemDAO(conn);
        var a = itemDAO.searchById(1L);
        var b = itemDAO.searchById(100L);
        System.out.println(a);
        System.out.println(b);
        var c = itemDAO.searchByKeyword("of");
        var d = itemDAO.searchByKeyword("Gay");
        System.out.println(c);
        System.out.println(d);
        itemDAO.create(a, "Gay", "saf", BigDecimal.valueOf(15.5), BigDecimal.valueOf(156.564));
        var c1 = itemDAO.searchByKeyword("of");
        var d1 = itemDAO.searchByKeyword("Gay");
        System.out.println(c1);
        System.out.println(d1);
    }
}
