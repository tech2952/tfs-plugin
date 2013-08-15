$LOAD_PATH.unshift File.expand_path("./../../../BuildAndDeploy/BuildTools")
$LOAD_PATH.unshift File.expand_path("./../../../BuildAndDeploy/BuildTools/Jenkins")
$LOAD_PATH.unshift File.expand_path("./../../../BuildAndDeploy/TestTools")
$LOAD_PATH.unshift File.expand_path("\\\\cr-public-a01r\\DevToolsRepository\\BuildAndDeploy\\BuildTools")
$LOAD_PATH.unshift File.expand_path("\\\\cr-public-a01r\\DevToolsRepository\\BuildAndDeploy\\BuildTools\\Jenkins")
$LOAD_PATH.unshift File.expand_path("\\\\cr-public-a01r\\DevToolsRepository\\BuildAndDeploy\\TestTools")
puts $LOAD_PATH

require 'Package'
require 'Solution'
require 'Project'
require 'ChangeSet'
require 'SolutionFile'

sampleCenterProjectNames = %w[
  SampleCenter.WinForm
  ]

sampleCenterSolution = Solution.new("SampleCenter", Array.new(), Array.new())

sampleCenterSolution.files << SolutionFile.new("Rakefile",  Array.new())
  
sampleCenterProjectNames.each() do |name|
  sampleCenterSolution.projects << Project.new(name, Array.new(), true)
end

sampleCenterSolutions = Array.new()
sampleCenterSolutions << sampleCenterSolution

sampleCenter = Package.new("SampleCenter", sampleCenterSolutions)

sampleCenter.solutions.each() do |solution|
  puts solution.name
  solution.projects.each() do |project|
    puts "   #{project.name} : Deploy = #{project.shouldDeploy}"
  end
  
  puts "\n"
  
  solution.files.each() do |file|
    puts "   #{file.name}"
  end
  puts "\n"
end

sampleCenter.toFile("Packages/samplecenterPackage.yml")

puts "Done"

