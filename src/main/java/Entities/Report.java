package Entities;

import java.time.LocalDate;

public class Report {
    private long reportId, userId;
    private LocalDate lastGeneratedIn;
    private String[] details;

    public Report(long reportId, long userId, String[] details) {
        this.reportId = reportId;
        this.userId = userId;
        this.details = details;

        setLastGeneratedIn(LocalDate.now());
    }

    public Report(long userId, String[] details) {
        this.userId = userId;
        this.details = details;

        setLastGeneratedIn(LocalDate.now());
    }

    public void setLastGeneratedIn(LocalDate lastGeneratedIn) {
        this.lastGeneratedIn = lastGeneratedIn;
    }

}
