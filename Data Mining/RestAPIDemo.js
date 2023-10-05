const express = require("express");
const mongoose = require("mongoose");
const Student = require("./Model/Student");
const bodyParser = require("body-parser");
mongoose
  .connect(
    "mongodb+srv://divyank:divyank@cluster0.m70l1zn.mongodb.net/Colleges"
  )
  .then(() => {
    const app = express();
    app.use(bodyParser.urlencoded({ extended: false }));
    app.get("/", async (req, res) => {
      const data = await Student.find();
      res.send(data);
    });
    app.get("/:id", async (req, res) => {
      const data = await Student.findOne({ StudentId: req.params.id });
      res.send(data);
    });
    app.delete("/:id", async (req, res) => {
      const data = await Student.deleteOne({ StudentId: req.params.id });
      res.send(data);
    });
    app.post("/add", async (req, res) => {
      const stu = new Student();
      stu.StudentName = req.body.SN;
      stu.StudentId = req.body.SID;
      const data = await stu.save();
      res.send(data);
    });
    app.put("/edit/:id", async (req, res) => {
      const data = await Student.findOne({ StudentId: req.params.id });
      data.StudentName = req.body.SN;
      data.StudentId = req.body.SID;
      await data.save();
      res.send(data);
    });
    app.listen(2002, (req, res) => {
      console.log("Server Started at @ 2002");
    });
  });
