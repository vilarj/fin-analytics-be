package Services;

import Entities.Report;
import org.springframework.stereotype.Service;
import java.sql.*;
import java.time.LocalDate;

@Service
public class ReportService {
    private static final String DB_URL = "jdbc:sqlite:./Database/FinAnalyticsDB.db";

    public Report GetReport(long reportId) {
        String query = "SELECT reportId, userId, details, lastGeneratedIn FROM Report WHERE reportId = ?";
        Report report = null;

        try (Connection conn = DriverManager.getConnection(DB_URL);
             PreparedStatement pstmt = conn.prepareStatement(query)) {

            pstmt.setLong(1, reportId);

            try (ResultSet rs = pstmt.executeQuery()) {
                if (rs.next()) {
                    long id = rs.getLong("ReportId");
                    long userId = rs.getLong("UserId");
                    String[] details = rs.getString("Details").split(",");
                    LocalDate lastGeneratedIn = LocalDate.parse(rs.getString("LastGeneratedIn"));
                    report = new Report(id, userId, details);
                    report.setLastGeneratedIn(lastGeneratedIn);
                }
            }
        } catch (SQLException e) {
            throw new RuntimeException("Error querying the database", e);
        }

        return report;
    }

}
