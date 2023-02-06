const PROXY_CONFIG = [
  {
    context: [
      "/Usuarios",
    ],
    target: "https://localhost:7121/api",
    secure: true
  }
]

module.exports = PROXY_CONFIG;
