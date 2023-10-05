const mongoose = require("mongoose");
const schema = mongoose.Schema({
  StudentId: Number,
  StudentName: String,
},{collection:""});
module.exports = mongoose.model("students", schema);
