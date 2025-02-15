pipeline {
    agent any

    environment {
        DOTNET_VERSION = '8.0' // Specify .NET 8
        PROJECT_DIR = 'Devops_practice' // Path to the folder containing the .NET project
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/Nikshay123/Devops-practice.git' // Your repository URL
            }
        }

        stage('Restore') {
            steps {
                dir(env.PROJECT_DIR) { // Navigate to the project directory
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir(env.PROJECT_DIR) { // Navigate to the project directory
                    sh 'dotnet build --configuration Release --no-restore'
                }
            }
        }

        stage('Test') {
            steps {
                dir(env.PROJECT_DIR) { // Navigate to the project directory
                    sh 'dotnet test --no-restore --verbosity normal'
                }
            }
        }

        stage('Publish') {
            steps {
                dir(env.PROJECT_DIR) { // Navigate to the project directory
                    sh 'dotnet publish --configuration Release --output ./publish --no-restore'
                }
            }
        }
    }

    post {
        success {
            echo 'Pipeline succeeded!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}
