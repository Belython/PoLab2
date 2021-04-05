(Title, Artist, ReleaseDate, ListPrice, Price, Version)

import java.sql.*;
import java.util.Arrays;

public class FirstClass {
    public static void main(String[] args) {
        String strUrl = "jdbc:dbf:/d://dbf";
        String[] stWork = {"INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ('Diva', 'Annie Lennox', ctod('1992-01-04'), 17.97, 13.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Dream of the Blue Turtles', 'Sting', ctod('1985-02-05'), 17.97, 14.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Trouble is...', 'Kenny Wayne Shepherd Band',ctod('1997-08-08'), 17.97, 14.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Lie to Me', 'Jonny Lang',ctod('1997-08-26'), 17.97, 14.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Little Earthquakes', 'Tori Amos',ctod('1992-01-18'), 17.97, 14.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Seal', 'Seal',ctod('1991-08-18'), 17.97, 14.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Ian Moore', 'Ian Moore',ctod('1993-12-05'), 9.97, 9.97,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'So Much for the Afterglow', 'Everclear',ctod('1997-01-19'), 16.97, 13.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Surfacing', 'Sarah McLachlan',ctod('1997-12-04'), 17.97, 13.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Hysteria', 'Def Leppard',ctod('1987-06-20'), 17.97, 14.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES  ( 'A Life of Saturdays', 'Dexter Freebish',ctod('2000-12-06'), 16.97, 12.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Human Clay', 'Creed',ctod('1999-10-21'), 18.97, 13.28,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'My, I''m Large', 'Bobs',ctod('1987-02-20'), 11.97, 11.97,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES  ( 'So', 'Peter Gabriel',ctod('1986-10-03'), 17.97, 13.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES  ( 'Big Ones', 'Aerosmith',ctod('1994-05-08'), 18.97, 14.99,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES  ( '90125', 'Yes',ctod('1983-10-16'), 11.97, 11.97,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES  ( '1984', 'Van Halen',ctod('1984-08-19'), 11.97, 11.97,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Escape', 'Journey',ctod('1981-02-25'), 11.97, 11.97,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Greatest Hits', 'Jay and the Americans',ctod('1966-12-05'), 13.99, 9.97,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Ray of Light', 'Madonna',ctod('2000-12-15'), 14.99, 10.97,1)",
                "INSERT INTO item7 (Title, Artist, ReleaseDate, ListPrice, Price, Version) VALUES ( 'Music', 'Madonna',1/2+ctod('2002-02-27'), 14.99, 11.97,1)"
        };

        try (Connection conDbf = DriverManager.getConnection(strUrl);) {
            Statement stDbf = conDbf.createStatement();
            Arrays.asList(stWork).forEach(e-> {
                try {
                    stDbf.executeUpdate(e);
                } catch (SQLException e1) {
                    e1.printStackTrace();
                }
            });
/*
            while (rsWork.next()) {
                System.out.printf("id=%.0f,name=%s,date=%s\n",
                        rsWork.getBigDecimal("item_id"),
                        rsWork.getString("artist"),
                        rsWork.getDate("releasedate")
                );
            }
*/
            String sCreate = "CREATE TABLE items2\n" +
                    "(\n" +
                    "   ITEM_ID     integer autoinc ,\n" +
                    "   Title       CHAR(40),\n" +
                    "   Artist      CHAR(40),\n" +
                    "   ReleaseDate DATE,\n" +
                    "   ListPrice   numeric(5,2),\n" +
                    "   Price       numeric(5,2),\n" +
                    "   Version     numeric(5)\n" +
                    ")";
//            stDbf.executeUpdate(sCreate);
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }
}
//https://www.dbase.com/dbasesql/dbase-documentation-download/
