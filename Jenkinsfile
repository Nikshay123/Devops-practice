pipeline {
    agent any

    environment {
        DOTNET_VERSION = '8.0' // Specify .NET 8
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/Nikshay123/Devops-practice.git' // Your repository URL
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test --no-restore --verbosity normal'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish --configuration Release --output ./publish --no-restore'
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
