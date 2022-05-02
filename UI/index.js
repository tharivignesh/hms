const express = require('express')
const app = express()
app.use(express.static(__dirname + '/src'));
const httpPort = 3000
app.listen(httpPort, () => { console.log(`server is up on http port ${httpPort}`) })