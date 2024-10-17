"use client"
import React from 'react';

export default function Dashboard() {
  return (
    <div className="dashboard">
      <header className="header">
        <button className="icon-button" aria-label="Menu">
          ☰
        </button>
        <h1>Dashboard</h1>
        <div className="header-actions">
          <button className="icon-button" aria-label="Notifications">
            🔔
          </button>
          <button className="icon-button" aria-label="User profile">
            👤
          </button>
        </div>
      </header>
      <div className="main-container">
        <aside className="sidebar">
          <nav>
            <ul>
              <li><a href="#" className="active">Home</a></li>
              <li><a href="#">Analytics</a></li>
              <li><a href="#">Reports</a></li>
              <li><a href="#">Settings</a></li>
            </ul>
          </nav>
        </aside>
        <main className="main-content">
          <div className="search-container">
            <span className="search-icon" aria-hidden="true">🔍</span>
            <input type="text" placeholder="Search..." className="search-input" />
          </div>
          <div className="card-container">
            <div className="card">
              <h2>Total Users</h2>
              <p className="card-value">10,234</p>
            </div>
            <div className="card">
              <h2>Revenue</h2>
              <p className="card-value">$54,321</p>
            </div>
            <div className="card">
              <h2>Active Projects</h2>
              <p className="card-value">23</p>
            </div>
          </div>
        </main>
      </div>
    </div>
  );
}