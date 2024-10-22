package controllers;

import Entities.Report;
import Services.ReportService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("v1/api/Reports")
public class ReportsController {

    @Autowired
    private ReportService service;

    @GetMapping("/getReport/{reportId}")
    public Report GetReport(@PathVariable long reportId){
        return service.GetReport(reportId);
    }
}
