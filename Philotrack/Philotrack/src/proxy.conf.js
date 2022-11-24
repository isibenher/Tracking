const PROXY_CONFIG = [
  {
    context: [
      "/api/siglums",
    ],
    target: "https://localhost:7243",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
