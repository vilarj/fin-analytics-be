package Services;

import Entities.User;
import org.springframework.stereotype.Service;
import java.sql.*;
import java.time.LocalDate;

@Service
public class UserService {
    private static final String DB_URL = "jdbc:sqlite:./Database/FinAnalyticsDB.db";

        public User CreateUser(String fullName, LocalDate DoB, String phone, String address, String email, String company) {
        String query = "INSERT INTO USERS (fullName, DoB, phone, address, email, company, createdOn) " +
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

        try (Connection conn = DriverManager.getConnection(DB_URL);
             PreparedStatement pstmt = conn.prepareStatement(query, Statement.RETURN_GENERATED_KEYS)) {

            pstmt.setString(1, fullName);
            pstmt.setString(2, DoB.toString());
            pstmt.setString(3, phone);
            pstmt.setString(4, address);
            pstmt.setString(5, email);
            pstmt.setString(6, company);
            pstmt.setString(7, LocalDate.now().toString());

            int affectedRows = pstmt.executeUpdate();
            if (affectedRows > 0) {
                ResultSet generatedKeys = pstmt.getGeneratedKeys();
                if (generatedKeys.next()) {
                    long userId = generatedKeys.getLong(1);
                    System.out.println("User created successfully with ID: " + userId);
                    return new User(fullName, DoB, phone, address, email, null, LocalDate.now()); // Assuming User constructor includes userId
                }
            }

        } catch (SQLException e) {
            System.err.println("Error while inserting user: " + e.getMessage());
        }

        return null;
    }

    public User GetUser(long id) {
        String query = "SELECT userId, fullName, DoB, phone, address, email, company, createdOn FROM USERS WHERE userId = ?";

        try (Connection conn = DriverManager.getConnection(DB_URL);
             PreparedStatement pstmt = conn.prepareStatement(query)) {

            pstmt.setLong(1, id);

            ResultSet rs = pstmt.executeQuery();

            if (rs.next()) {
                long userId = rs.getLong("userId");
                String fullName = rs.getString("fullName");
                LocalDate doB = LocalDate.parse(rs.getString("DoB"));
                String phone = rs.getString("phone");
                String address = rs.getString("address");
                String email = rs.getString("email");
                String company = rs.getString("company");
                LocalDate createdOn = LocalDate.parse(rs.getString("createdOn"));

                return new User(fullName, doB, phone, address, email, company, createdOn);
            } else {
                System.out.println("User with ID " + id + " not found.");
            }

        } catch (SQLException e) {
            System.err.println("Error while retrieving user: " + e.getMessage());
        }

        return null;
    }
}
